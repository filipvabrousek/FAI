import numpy
import sys





val = input("Zadejte vstupní řetězec:")
val1 = val;
if (len(sys.argv)>1):
  val1=sys.argv[1]

def encode(m, g):
  en = numpy.dot(m, g)%2
  return en

def decode(m, h):
  dec = numpy.dot(h, m)%2
  return dec

def flipbit(enc,bitpos):

  if (enc[bitpos]==1):
    enc[bitpos]=0
  else:
    enc[bitpos]=1
  return enc
	

def hamming(inp):
  g =  numpy.array([[1, 0, 0, 0, 1, 1, 1],[0, 1, 0, 0, 0, 1, 1],[ 0, 0 ,1 ,0 ,1 ,0 ,1],[0, 0, 0, 1, 1, 1, 0]])
  h = numpy.array([[ 1, 0, 1, 1, 1, 0, 0],[1 ,1 ,0 ,1 ,0 ,1 ,0],[ 1 ,1, 1, 0, 0, 0, 1],])
  
  inp = inp[:4]

  enc = encode(inp, g)

  dec = decode(enc, h)
  print ("Vstup  \t\tKódováno (0 ch.)  \tPozice chyby")
  print (inp,"\t",enc,"\t",dec)

  print ("----------------------")
  print ("Jednotlivé chyby")
  print ("Vstup  \t\tKódováno (1 ch.)  \tPozice chyby")
  for i in range (0,7):
    enc = encode(inp, g)
    enc1=flipbit(enc,i)
    dec = decode(enc1, h)
    print (inp,"\t",enc1,"\t",dec)

# '0' is 48 decimal
inp =  numpy.frombuffer(val1.encode(), dtype=numpy.uint8)-ord('0')
print (inp)
hamming(inp)
