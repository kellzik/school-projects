# Nelja arvu maksimum kasutades korduslauset
arv = int(input("Sisesta esimene arv: "))
max = arv
for loendur in range(2,5):
    arv = int(input("Sisesta järgmine arv: "))
    if (arv > max):
        max = arv
print("Maksimum = " + str(max))
