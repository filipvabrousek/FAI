## Tasks

```swift

import SwiftUI

class Task {
    var title: String
    var content: String

    init(title: String, date: String) {
        self.title = title
        self.content = date
    }
}

struct ContentView: View {
    @State var tasks = [Task]()
    @State var item = ""

    var d: DateFormatter = {
        let d = DateFormatter()
        d.dateFormat = "dd/MM/yyyy"
        return d
    }()

    var body: some View {
        VStack {
            HStack {
                Text("Tasks")
                    .font(.largeTitle)

                Spacer()

                Button("+") {
                    let t = Task(title: self.item, date: self.d.string(from: Date()))
                    self.tasks.append(t)
                    self.item = ""
                }
            }.padding()

            TextField("Enter a task.", text: $item)
                .padding()

            List(tasks, id: \.content) { t in
                VStack(alignment: .leading) {
                    Text(t.title)
                    Text(t.content)
                }
            }
        }
    }
}
```
