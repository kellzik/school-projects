# N arvu maksimum kasutades korduslauset
print("Mitut arvu töötleme? ")
n = int(input())
for k in range(1, n + 1, 1):
    print("Sisesta arv: ")
    arv = int(input())
    if k == 1:
        max = arv
    else:
        if arv > max:
            max = arv
print("Maksimum = " + str(max))