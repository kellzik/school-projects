arv = int(input("Sisesta esimene arv: "))
vahe = int(input("Sisesta vahe: "))
n = int(input("Sisesta mitu arvu soovid jadasse lisada: "))
summa = 0
j2rgminearv = arv
for i in range(1,n+1):
    if i > 1 and j2rgminearv >= 0:
        print("+", end="")
    print(j2rgminearv, end="")
    summa = summa + j2rgminearv
    j2rgminearv = j2rgminearv + vahe
print("=" + str(summa))