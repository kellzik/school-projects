/*
Kodutöö 2:


Märkus: Koodi kommentaarid on lisatud õppetöö eesmärgil, et selgitada koodilõikude konteksti ja kinnistada arusaamist programmi toimimisest. 
Kui koodis esineb mõni seni õppematerjalides käsitlemata meetod jmt, siis selgitab kommentaar selle eesmärki.
*/
using System.Net.Http;
using System.Xml;
using System.Xml.Linq;

namespace Kodutoo2_RSS_voogude_agregaator;

public class RssItem
{
    public string LinkUudisele { get; set; }
    public string Pealkiri { get; set; }
    public string Kirjeldus { get; set; }
    public string AvaldamiseAeg { get; set; }
}

class Program
{
    private static readonly string[] uudisteVoogudeAadressid =
    {
        "https://feeds.feedburner.com/aripaev-rss",
        "https://online.le.ee/feed/",
        "https://www.err.ee/rss"
    };

    static async Task Main(string[] args)
    {
        string kataloog = @"C:\temp";
        Directory.CreateDirectory(kataloog);
        string failiTee = Path.Combine(kataloog, "uudised.xml");

        XDocument dokument;
        if (File.Exists(failiTee))
        {
            dokument = XDocument.Load(failiTee);
        }
        else
        {
            dokument = new XDocument(new XElement("uudised"));
        }

        XElement? juur = dokument.Root;
        if (juur == null)
        {
            throw new InvalidDataException("Uudiste XML-failil puudub juurelement.");
        }

        using HttpClient client = new HttpClient();

        foreach (string vooAadress in uudisteVoogudeAadressid)
        {
            string rssXmlTekst = await client.GetStringAsync(vooAadress);
            List<RssItem> uudised = LoeUudised(rssXmlTekst);

            // Loen igast uudisteportaalist sisse viimased 20 uudist
            foreach (RssItem uudis in uudised.Take(20))
            {
                juur.Add(new XElement("uudis",
                    new XAttribute("avaldaja", vooAadress),
                    new XElement("pealkiri", uudis.Pealkiri),
                    new XElement("link", uudis.LinkUudisele),
                    new XElement("kirjeldus", uudis.Kirjeldus),
                    new XElement("avaldatud", uudis.AvaldamiseAeg)
                ));
            }
        }

        dokument.Save(failiTee);
    }

    static List<RssItem> LoeUudised(string rssTekst)
    {
        // Muudan RSS-i XML teksti XML dokumendiks, et selle elemente saaks lugeda.
        XDocument rssDokument = XDocument.Parse(rssTekst);

        List<RssItem> uudised = new List<RssItem>();

        // Käin XML dokumendi kõik elemendid läbi. Descendants() tagastab kõik juurelemendi sees asuvad alamelemendid.
        foreach (XElement xmlElement in rssDokument.Descendants())
        {
            // RSS kasutab uudise kohta tavaliselt elementi "item".
            if (xmlElement.Name.LocalName == "item")
            {
                string pealkiri = LeiaAlamelemendiVaartus(xmlElement, "title");
                string link = LeiaLink(xmlElement);
                string kirjeldus = LeiaAlamelemendiVaartus(xmlElement, "description");
                string avaldamiseAeg = LeiaAlamelemendiVaartus(xmlElement, "pubDate");

                // Panen leitud väljad uude RssItem-objekti ja lisan loendisse.
                RssItem uudis = new RssItem();
                uudis.Pealkiri = pealkiri;
                uudis.LinkUudisele = link;
                uudis.Kirjeldus = kirjeldus;
                uudis.AvaldamiseAeg = avaldamiseAeg;
                uudised.Add(uudis);
            }
        }

        return uudised;
    }

    // Loon uue meetodi LeiaAlamelemendiVaartus, mis otsib uudise XML-kirjest etteantud nimega alamelemendi ja tagastab selle sisu. Kui elementi ei leita, tagastab tühja teksti.
    static string LeiaAlamelemendiVaartus(XElement uudiseElement, string otsitavElement)
    {
        // Otsin etteantud nimega alamelementi.
        foreach (XElement alamelement in uudiseElement.Elements())
        {
            if (alamelement.Name.LocalName == otsitavElement)
            {
                // Tagastan elemendi teksti, näiteks <title>Uudise pealkiri</title> korral "Uudise pealkiri".
                return alamelement.Value;
            }
        }
        // Tagastan tühja teksti, kui elementi ei leitud.
        return "";
    }

    static string LeiaLink(XElement uudiseElement)
    {
        // Otsin uudise seest "link" elementi.
        foreach (XElement alamelement in uudiseElement.Elements())
        {
            if (alamelement.Name.LocalName == "link")
            {
                // RSS-voos võib aadress olla elemendi tekstina.
                return alamelement.Value;
            }
        }
        // Tagastan tühja teksti, kui link puudub.
        return "";
    }
}
