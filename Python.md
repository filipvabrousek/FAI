## Python

```python
print("Hello FAI!") # 8:37:00 FAI

people = ["Filip", "Terka"]
for x in range(6): print(x)

# Average
n =  [2, 4, 6]
sum = 0
for x in n: sum += x;
res = sum / len(n);
print("Res is " + res);

# Iterator
tuple = ("Sára", "Filip")
it = iter(tuple)
print(next(it))


def Fib(n):
    if n < 0:
        print("Incorrect input");

    elif n == 1:
        return 0;

    elif n == 2:
        return 1;

    else:
         return Fib(n - 1) + Fib(n - 2)


    class Morse:
        def _init_(self, text):
            self.text = text
        def getMorse(self): print("Hello I am self")

     m = Morse("Filip")
     m.getMorse();


codes = { 'A':'.-', 'B':'-...',
                    'C':'-.-.', 'D':'-..', 'E':'.',
                    'F':'..-.', 'G':'--.', 'H':'....',
                    'I':'..', 'J':'.---', 'K':'-.-',
                    'L':'.-..', 'M':'--', 'N':'-.',
                    'O':'---', 'P':'.--.', 'Q':'--.-',
                    'R':'.-.', 'S':'...', 'T':'-',
                    'U':'..-', 'V':'...-', 'W':'.--',
                    'X':'-..-', 'Y':'-.--', 'Z':'--..',
                    '1':'.----', '2':'..---', '3':'...--',
                    '4':'....-', '5':'.....', '6':'-....',
                    '7':'--...', '8':'---..', '9':'----.',
                    '0':'-----', ', ':'--..--', '.':'.-.-.-',
                    '?':'..--..', '/':'-..-.', '-':'-....-',
                    '(':'-.--.', ')':'-.--.-'}


def decrypt(m):
    m += ""
    decipher = ""
    citext = ""

    for l in m:
        if (l != ""):
            i = 0;
            citext += l;

        else:
            i += 2;

            if i == 2:
                decipher += ' '

            else:
                decipher += list(codes.keys())[list(codes.values()).index(citext)];
                citext = ' '

    return decipher
```

* SPV: Docházka, 4 lidi do projektu 
* Java: 8:16:20 - System.out.print("Hello Java")
* Python: 8:37:00 print("Hello FAI")
