## Python-RSA 26-01-21-v1

```python
import tkinter as tk
from tkinter import *
from tkinter.ttk import *
import sympy


def TextToNumber(text):
    return [(int(''.join([(f'{number:010b}') for number in numberList]), 2)) for numberList in
            [([(ord(letter)) for letter in section]) for section in [(text[i:i + 7]) for i in range(0, len(text), 7)]]]


def NumberToText(numbers):
    return ''.join(
        [(''.join([(chr(int(binaryNumber[i:i + 10], 2)).replace('\x00', '')) for i in range(0, len(binaryNumber), 10)]))
         for binaryNumber in [(f'{number:070b}') for number in numbers]])


def GenerateKeys():
    p, q = sympy.randprime(10 ** 19, 10 ** 20), sympy.randprime(10 ** 19, 10 ** 20)
    phi_n = (p - 1) * (q - 1)
    n = p * q

    e = sympy.randprime(2, phi_n)
    d = pow(e, -1, phi_n)

    print("E")
    print(e)

    print("D")
    print(d)

    return str(n), str(e), str(d)


def Encrypt(plainText, n, e):
    return ' '.join([(str(pow(number, int(e), int(n)))) for number in TextToNumber(plainText)])


def Decrypt(encodedText, n, d):
    return NumberToText([(pow(int(number), int(d), int(n))) for number in encodedText.split(' ')])


def print_hi(name):
    # Use a breakpoint in the code line below to debug your script.
    print(f'Hi, {name}')  # Press ⌘F8 to toggle the breakpoint.


# encryptedVar = tkinter.StringVar()


encryptedText = ""
N = ""
ENumber = ""
D = ""


def helloCallBack():
    print("Value")
    print(E.get())

    # encrypted = Encrypt(E.get(), 39)
    keys = GenerateKeys()
    N = keys[0]
    ENumber = keys[1]
    D = keys[2]

    print("N:", keys[0], "E", keys[1], "D", keys[2])





class Test():
    def generateKeysOnClick(self):
        print("Generating")

        keys = GenerateKeys()

        self.NPrimeValue.set(keys[0])
        self.EPrimeValue.set(keys[1])
        self.DEntryValue.set(keys[2])


    def __init__(self):
        self.root = tk.Tk()
        self.text = tk.StringVar()
        self.text.set("Test")
        self.label = tk.Label(self.root, textvariable=self.text)

        # ---------------------------------------------- STYLES ---------------------------------------------

        # ---------------------------------------------- STRING VARS ----------------------------------------------
        self.encryptValue = tk.StringVar()
        self.EPrimeValue = tk.StringVar()
        self.NPrimeValue = tk.StringVar()
        self.DEntryValue = tk.StringVar()
        self.phraseToEncrypt = tk.StringVar()
        self.decryptedText = tk.StringVar()

        self.privateKey = tk.StringVar()
        self.publicKey = tk.StringVar()

        # ---------------------------------------------- SET DEFAULT VALUES ----------------------------------------------
        self.EPrimeValue.set("-")
        self.NPrimeValue.set("-")

        self.ELabel = tk.Label(text="Enter E prime number")
        self.NLabel = tk.Label(text="Enter N prime number")
        self.DLabel = tk.Label(text = "Enter D number")

        self.EEntry = tk.Entry(textvariable=self.EPrimeValue)
        self.NEntry = tk.Entry(textvariable=self.NPrimeValue)
        self.DEntry = tk.Entry(textvariable=self.DEntryValue)

        # E: 409519438965343006289656381889706943057
        # N: 792557954858978963581099474552990968343
        # D: 378688434720200721778864570557510971193


        # ---------------------------------------------- PRIME LABELS ----------------------------------------------
        self.NPrimeTitleLabel = tk.Label(text="N Prime number")
        self.nPrimeLabel = tk.Label(textvariable=self.NPrimeValue, fg='#3498db', font = ("Arial", 20))

        self.EPrimeTitleLabel = tk.Label(text="E Prime number")
        self.ePrimeLabel = tk.Label(textvariable=self.EPrimeValue, fg='#3498DB', font = ("Arial", 20))

        # self.encryptValue.set("none")
        self.label = tk.Label(self.root, textvariable=self.encryptValue)

        self.button = tk.Button(self.root, text="ENCRYPT", command=self.changeText, font = ("Arial", 14), fg = "#3498db", padx = 7, pady = 7)
        self.enterValueToEncrypt = tk.Label(text="Enter a value to encrypt")
        self.decryptLabel = tk.Label(textvariable=self.decryptedText)
        self.inputField = tk.Entry()

        self.decryptButton = tk.Button(self.root, text="DECRYPT", command=self.decryptText, font = ("Arial", 14), fg = "#3498db", padx = 7, pady = 7)

        self.generateKeysButton = tk.Button(self.root, text="GENERATE KEYS", command=self.generateKeysOnClick, font = ("Arial", 14), fg = "#3498db", padx = 7, pady = 7)

        self.privateKeyLabel = tk.Label(textvariable=self.privateKey)
        self.publicKeyLabel = tk.Label(textvariable=self.publicKey)


        self.generateKeysButton.pack()

        self.ELabel.pack()
        self.EEntry.pack()

        self.NLabel.pack()
        self.NEntry.pack()

        self.DLabel.pack()
        self.DEntry.pack()

        self.publicKeyLabel.pack()
        self.privateKeyLabel.pack()

        self.enterValueToEncrypt.pack()
        self.inputField.pack()

        self.button.pack()
        self.label.pack()
        self.decryptButton.pack()
        self.decryptLabel.pack()


        self.root.mainloop()

    def Encrypt(plainText, n, e):
        return ' '.join([(str(pow(number, int(e), int(n)))) for number in TextToNumber(plainText)])

    def Decrypt(encodedText, n, d):
        return NumberToText([(pow(int(number), int(d), int(n))) for number in encodedText.split(' ')])


    def decryptText(self):
        #  keys = GenerateKeys()

        N = self.NEntry.get()  # self.keys[0]
        ENumber = self.EEntry.get()  # self.keys[1]
        D = self.DEntry.get()  # self.keys[2]

        decrypted = Decrypt(self.encrypted, N, D) #self.keys[0], self.keys[2])

        print("KEYS[0]: N" + self.keys[0])
        print("KEYS[2]: D" + self.keys[2])
        print("ENCRYPT: " + self.encrypted)
        print("DECA " + decrypted)

        self.decryptedText.set(decrypted)

    def changeText(self):
        self.keys = GenerateKeys()

        N = self.NEntry.get() # self.keys[0]
        ENumber = self.EEntry.get()#self.keys[1]
        D = self.DEntry.get() #self.keys[2]

        print("N:", self.keys[0], "E", self.keys[1], "D", self.keys[2])

        # self.EPrimeValue.set(self.keys[1])
        #self.NPrimeValue.set(self.keys[2])
        self.encrypted = Encrypt(self.inputField.get(), N, ENumber) #self.keys[0], self.keys[1])
        self.encryptValue.set(self.encrypted)  # .text.set("Text updated")

        self.privateKey.set("Private key: [" + N + "," + D + "]")
        self.publicKey.set("Public key: [" + N + "," + ENumber + "]")



app = Test()

# Press the green button in the gutter to run the script.
if __name__ == '__main__':
    print_hi('PyCharm')











# See PyCharm help at https://www.jetbrains.com/help/pycharm/

# top = Tkinter.Tk()
# Code to add widgets will go here...
# top.mainloop()


# 23:36:00 - alertBox
# 23:31:40
```
