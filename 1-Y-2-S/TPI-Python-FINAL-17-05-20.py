import numpy
import sys

letter = input("Zadejte malé písmeno: ");

numbers = ["0000", "0001", "0010", "0011", "0100", "0101", "0110", "0111", "1000", "1001", "1010", "1011", "1100", "1101", "1110", "1111"];

a=ord('a')
alph=[chr(i) for i in range(a,a+26)]

val = letter

# nalezení odpovídajícího binárního kódu v listu 
val1 =  numbers[alph.index(val)] 
if (len(sys.argv)>1):
  val1=sys.argv[1]


# zakódování
def encode(m, g):
  en = numpy.dot(m, g)%2
  return en

# dokódování
def decode(m, h):
  dec = numpy.dot(h, m)%2
  return dec


# záměna bitů
def flipbit(enc,bitpos):

  if (enc[bitpos]==1):
    enc[bitpos]=0
  else:
    enc[bitpos]=1
  return enc
	

# hamingův algoritmus
def hamming(inp):
  g =  numpy.array([   # generující matice G
  [1, 0, 0, 0, 1, 1, 0],
  [0, 1, 0, 0, 1, 0, 1],
  [0, 0 ,1 ,0 ,0 ,1 ,1],
  [0, 0, 0, 1, 1, 1, 1]])

  h = numpy.array([   # kontrolní matice H
  [ 1, 1, 0, 1, 1, 0, 0],
  [1 ,0 ,1 ,1 ,0 ,1 ,0],
  [ 0 ,1, 1, 1, 0, 0, 1],])
  
  inp = inp[:4] # vstupní slovo
  enc = encode(inp, g)
  dec = decode(enc, h)

  print ("Vstup  \t\tKód (0 chyb)  \tPozice chyby")
  print (inp,"\t",enc,"\t",dec)

  print ("----------------------")
  print ("Vstup  \t\tKód (1 chyba)  \tPozice chyby")
  for i in range (0,7):
    enc = encode(inp, g)
    enc1=flipbit(enc,i)
    dec = decode(enc1, h)
    print (inp,"\t",enc1,"\t",dec)

# '0' is 48 decimal
inp =  numpy.frombuffer(val1.encode(), dtype=numpy.uint8)-ord('0')
print (inp)
hamming(inp)
