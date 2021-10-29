#Esto es un comentario
#Vamos a hacer el algoritmo del palindromo en diversos lenguajes.
#y demás ejemplos sacados de leetcode.
print("hola mundo")


def isPalindrome(x):
    if x < 0:
        return False
    else:
        return x == int(str(x)[::-1])


d = isPalindrome(9121219)
print((d))
