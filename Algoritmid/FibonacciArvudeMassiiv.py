# Fibonacci arvude massiiv
n=int(input("Sisesta Fibonacci arvude massiivi pikkus: "))
FibM=[0]*n
FibM[0]=0
FibM[1]=1
for i in range(2,n):
    FibM[i]=FibM[i-2]+FibM[i-1]
print(FibM)
print(*FibM)