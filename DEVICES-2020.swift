// UNIVERSAL CHECKER - 28/04/2020
import UIKit


public extension UIDevice {

    static let modelName: String = {
        var systemInfo = utsname()
        uname(&systemInfo)
        let machineMirror = Mirror(reflecting: systemInfo.machine)
        let identifier = machineMirror.children.reduce("") { identifier, element in
            guard let value = element.value as? Int8, value != 0 else { return identifier }
            return identifier + String(UnicodeScalar(UInt8(value)))
        }

        func mapToDevice(identifier: String) -> String { // swiftlint:disable:this cyclomatic_complexity
            #if os(iOS)
            switch identifier {
            case "iPod9,1":                                 return "iPod touch (7th generation)"
            case "iPhone8,1":                               return "iPhone 6s"
            case "iPhone8,2":                               return "iPhone 6s Plus"
            case "iPhone8,4":                               return "iPhone SE"
            case "iPhone9,1", "iPhone9,3":                  return "iPhone 7"
            case "iPhone9,2", "iPhone9,4":                  return "iPhone 7 Plus"
            case "iPhone10,1", "iPhone10,4":                return "iPhone 8"
            case "iPhone10,2", "iPhone10,5":                return "iPhone 8 Plus"
            case "iPhone10,3", "iPhone10,6":                return "iPhone X"
            case "iPhone11,2":                              return "iPhone XS"
            case "iPhone11,4", "iPhone11,6":                return "iPhone XS Max"
            case "iPhone11,8":                              return "iPhone XR"
            case "iPhone12,1":                              return "iPhone 11"
            case "iPhone12,3":                              return "iPhone 11 Pro"
            case "iPhone12,5":                              return "iPhone 11 Pro Max"
            case "iPhone12,8":                              return "iPhone SE (2nd generation)"
            case "iPhone13,1":                              return "iPhone 12 mini"
            case "iPhone13,2":                              return "iPhone 12"
            case "iPhone13,3":                              return "iPhone 12 Pro"
            case "iPhone13,4":                              return "iPhone 12 Pro Max"
            case "iPad6,11", "iPad6,12":                    return "iPad (5th generation)"
            case "iPad7,5", "iPad7,6":                      return "iPad (6th generation)"
            case "iPad7,11", "iPad7,12":                    return "iPad (7th generation)"
            case "iPad5,3", "iPad5,4":                      return "iPad Air 2"
            case "iPad11,3", "iPad11,4":                    return "iPad Air (3rd generation)"
            case "iPad13,1", "iPad13,2":                    return "iPad Air (4th generation)"
            case "iPad5,1", "iPad5,2":                      return "iPad mini 4"
            case "iPad11,1", "iPad11,2":                    return "iPad mini (5th generation)"
            case "iPad6,3", "iPad6,4":                      return "iPad Pro (9.7-inch)"
            case "iPad7,3", "iPad7,4":                      return "iPad Pro (10.5-inch)"
            case "iPad8,1", "iPad8,2", "iPad8,3", "iPad8,4":return "iPad Pro (11-inch) (1st generation)"
            case "iPad8,9", "iPad8,10":                     return "iPad Pro (11-inch) (2nd generation)"
            case "iPad6,7", "iPad6,8":                      return "iPad Pro (12.9-inch) (1st generation)"
            case "iPad7,1", "iPad7,2":                      return "iPad Pro (12.9-inch) (2nd generation)"
            case "iPad8,5", "iPad8,6", "iPad8,7", "iPad8,8":return "iPad Pro (12.9-inch) (3rd generation)"
            case "iPad8,11", "iPad8,12":                    return "iPad Pro (12.9-inch) (4th generation)"
            case "AppleTV5,3":                              return "Apple TV"
            case "AppleTV6,2":                              return "Apple TV 4K"
            case "AudioAccessory1,1":                       return "HomePod"
            case "i386", "x86_64":                          return "Simulator \(mapToDevice(identifier: ProcessInfo().environment["SIMULATOR_MODEL_IDENTIFIER"] ?? "iOS"))"
            default:                                        return identifier
            }
            #elseif os(tvOS)
            switch identifier {
            case "AppleTV5,3": return "Apple TV 4"
            case "AppleTV6,2": return "Apple TV 4K"
            case "i386", "x86_64": return "Simulator \(mapToDevice(identifier: ProcessInfo().environment["SIMULATOR_MODEL_IDENTIFIER"] ?? "tvOS"))"
            default: return identifier
            }
            #endif
        }

        return mapToDevice(identifier: identifier)
    }()
}

// ------------------------------------------------------------- IPHONE NAMES -------------------------------------------------------------
public extension UIDevice {
    var isSmall: Bool {
           let devices = ["iPhone SE", "Simulator iPhone SE", "iPod Touch (7th generation)", "Simulator iPod Touch (7th generation)"]
           
           let d = UIDevice.modelName
           if devices.contains(d){
               return true
           } else {
               return false
           }
       }
    
    var is47: Bool {
        let small = ["iPhone 6s", "iPhone 7", "iPhone 8", "iPhone SE (2nd generation)"]
        let sim = small.map {"Simulator \($0)"}
        let name = UIDevice.modelName
  
        
        print("NAMEDD \(name)")
        if (sim.contains(name) || small.contains(name)){
            print("506 CONT")
            return true
        } else {
            return false
        }
    }
    
    var is55: Bool {
          let small = ["iPhone 6s Plus", "iPhone 7 Plus", "iPhone 8 Plus"]
          let sim = small.map {"Simulator \($0)"}
          let name = UIDevice.modelName
    
          
          print("NAMEDD \(name)")
          if (sim.contains(name) || small.contains(name)){
              print("506 CONT")
              return true
          } else {
              return false
          }
      }
    
    var is6561: Bool {
        let small = ["Simulator iPhone XR", "Simulator iPhone XS Max", "iPhone XS Max", "iPhone XR", "iPhone 11 Pro Max", "iPhone 12 Pro Max", "Simulator iPhone 12 Pro Max"]
        let name = UIDevice.modelName

        if small.contains(name){
            print("506 CONT")
            return true
        } else {
            return false
        }
    }
    
    var is58: Bool {
        let small = ["iPhone X", "iPhone XS", "iPhone 11 Pro", "iPhone 12 Pro", "Simulator iPhone 12 Pro" ]
        let name = UIDevice.modelName
        
        if small.contains(name){
            print("506 CONT")
            return true
        } else {
            return false
        }
    }
}




class Checker {
    var p: String = ""

    func isIpad() -> Bool {
        return UIDevice.current.userInterfaceIdiom == .pad
    }


    func isIphone() ->  Bool {
        return UIDevice.current.userInterfaceIdiom == .phone
    }
    
    func is97Ipad() -> Bool {
        let devices = ["iPad Pro (9.7-inch)", "Simulator iPad Pro (9.7-inch)"]

        let device = UIDevice.modelName

        if (devices.contains(device)) {
            return true
        } else {
            return false
        }
    }
    
    func is105P() -> Bool {
          let devices = ["iPad Pro (10.5-inch)", "Simulator iPad Pro (10.5-inch)"]

          let device = UIDevice.modelName

          if (devices.contains(device)) {
              return true
          } else {
              return false
          }
      }
    
    func is11P() -> Bool {
            let devices = ["iPad Pro (11-inch)", "Simulator iPad Pro (11-inch)", "iPad Pro (11-inch) (2nd generation)", "iPad Air (4th generation)", "Simulator iPad Air (4th generation)"]

            let device = UIDevice.modelName

            if (devices.contains(device)) {
                return true
            } else {
                return false
            }
    }


    func isBiggestIpad() -> Bool {
        let devs = [
            "iPad Pro (12.9-inch)", "Simulator iPad Pro (12.9-inch)",
            "iPad Pro (12.9-inch) (2nd generation)", "Simulator iPad Pro (12.9-inch) (2nd generation)",
            "iPad Pro (12.9-inch) (3rd generation)", "Simulator iPad Pro (12.9-inch) (3rd generation)",
            "iPad Pro (12.9-inch) (4th generation)", "Simulator iPad Pro (12.9-inch) (4th generation)"]
        
        let device = UIDevice.modelName
        print("Device in is BiggestIPad \(device)")

        if (devs.contains(device)) {
            return true
        } else {
            return false
        }
    }


    func isSmallIpad() -> Bool {
        let devs = ["iPad 5", "Simulator iPad 5",
            "iPad 6", "Simulator iPad 6",
            "iPad Air", "Simulator iPad Air",
            "iPad Air 2", "Simulator iPad Air 2",
            "iPad Mini 3", "iPad Mini 4", // have no simulators, same as the iPad 9.7
            "iPad Pro (9.7-inch)", "Simulator iPad Pro (9.7-inch)",
            "iPad Air (3rd generation)", "Simulator iPad Air (3rd generation)"
        ]

        let device = UIDevice.modelName

        if (devs.contains(device)) {
            print("SMALL \(device)")
            return true
        } else {
            return false
        }
    }
    
    func is58() -> Bool {
        let devs = ["iPhone X", "iPhone XS", "iPhone 11 Pro"]
        let mapped = devs.map { "Simulator \($0)" }

        // "Simulator iPad Air (3rd generation)" NEW 2019
        let device = UIDevice.modelName

        if (devs.contains(device) || mapped.contains(device)) {
          //  print("PRO MODEL \(device)")
            return true
        } else {
            return false
        }
    }

    func is6561() -> Bool {
        let devs = ["iPhone XS Max", "iPhone XR", "iPhone 11", "iPhone 11 Pro Max", "iPhone 12 Pro Max", "Simulator iPhone 12 Pro Max"]
        let mapped = devs.map { "Simulator \($0)" }

        // "Simulator iPad Air (3rd generation)" NEW 2019
        let device = UIDevice.modelName

        if (devs.contains(device) || mapped.contains(device)) {
            print("SMALL \(device)")
            return true
        } else {
            return false
        }
    }

    func is4() -> Bool {
        let devs = ["iPhone SE"]
        let mapped = devs.map { "Simulator \($0)" }

        // "Simulator iPad Air (3rd generation)" NEW 2019
        let device = UIDevice.modelName

        if (devs.contains(device) || mapped.contains(device)) {
            print("SMALL \(device)")
            return true
        } else {
            return false
        }
    }

    func is47() -> Bool {
        let devs = ["iPhone 6s", "iPhone 7", "iPhone 8", "iPhone SE (2nd generation)"]
        let mapped = devs.map { "Simulator \($0)" }

        // "Simulator iPad Air (3rd generation)" NEW 2019
        let device = UIDevice.modelName

        if (devs.contains(device) || mapped.contains(device)) {
            print("SMALL \(device)")
            return true
        } else {
            return false
        }
    }

    
    // redundant method
    func isSmall() -> Bool {
        let devs = ["iPhone SE"]
        let mapped = devs.map { "Simulator \($0)" }

        // "Simulator iPad Air (3rd generation)" NEW 2019
        let device = UIDevice.modelName

        if (devs.contains(device) || mapped.contains(device)) {
            print("SMALL \(device)")
            return true
        } else {
            return false
        }
    }

    func is55() -> Bool {
        let devs = ["iPhone 7 Plus", "iPhone 8 Plus"]
        let mapped = devs.map { "Simulator \($0)" }

        // "Simulator iPad Air (3rd generation)" NEW 2019
        let device = UIDevice.modelName

        if (devs.contains(device) || mapped.contains(device)) {
            print("SMALL \(device)")
            return true
        } else {
            return false
        }
    }
}
