## Catalyst

```swift
import SwiftUI


// 8:20:10 FAI
struct ContentView: View {
    @State var people = ["Filip", "Jirka", "Terka"]
    @State var text = ""


    var body: some View {
        VStack {
            NavigationView {
                List {
                    ForEach(people, id: \.self) { p in
                        NavigationLink(destination: DetailView(person: p)) {
                            Row(p: p)
                        }
                    }
                }.navigationBarTitle("People")
            }
        }
    }
}


struct Row: View {
    var p: String
    
    var body: some View {
        HStack {
            Image("craig").resizable()
                .frame(width: 60, height: 60)
                .clipShape(Circle())
            Spacer()
            Text(p)
                .foregroundColor(Color.blue)
                .bold()
            Spacer()
        }
    }
}

struct DetailView: View {
    var person: String
    var body: some View {
        Text(person).bold()
    }
}

struct ContentView_Previews: PreviewProvider {
    static var previews: some View {
        ContentView()
    }
}


```
