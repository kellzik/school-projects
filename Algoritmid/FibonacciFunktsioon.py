def FIB1(jn):
    if (jn<=0):
        f=0
    elif (jn==1):
        f=1
    else:
        F0=0
        F1=1
        for i in range(2, jn+1):
            jargmine=F0+F1
            F0=F1
            F1=jargmine
        f=jargmine
    return f

n=int(input("Mitu arvu on jadas?"))

for j in range(0,n+1):
    print(FIB1(j), end=" ")
