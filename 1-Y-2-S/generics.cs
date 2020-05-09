## Generics

```csharp
using System;

namespace GenericClass
{


    class GenericClass<T>{
        private T genericMemberVariable;

        public GenericClass(T value){
            genericMemberVariable = value;
        }

        public T genericProperty { get; set; }
    }


    class MainClass{
        public static void Main(string[] args){
            // používáme zástupný typ T, aby do generické třídy šlo uložit jakýkoli datový typ (např. int / string atd.)
            GenericClass<int> intGenericClass = new GenericClass<int>(10);
            GenericClass<string> stringGenericClass = new GenericClass<string>("Hello");
        }
    }
}




```
