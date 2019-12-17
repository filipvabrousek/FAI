class Run: NSObject, NSCoding {
    
    
    struct Keys {
        
        static let date = "date"
       }
       
       
        private var _date = ""
        
        
        override init() {}
        
        init(date: String){
        self._date = date
        }
        
        
         required init(coder aDecoder:NSCoder){
        
        if let DO = aDecoder.decodeObject(forKey: Keys.date) as? String{
            _date = DO
        }
        
        }
        
        func encode(with aCoder: NSCoder) {
        
        aCoder.encode(_date, forKey: Keys.date)
        
        }
        
         var date: String {
        get {
            return _date
        }
        
        set{
            _date = newValue
        }
    }
