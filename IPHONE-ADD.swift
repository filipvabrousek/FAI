//
//  File.swift
//  Runny
//
//  Created by Filip Vabroušek on 28/04/2020.
//  Copyright © 2020 Filip Vabroušek. All rights reserved.
//

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
            switch identifier {
                
            // IPHONE
            case "iPhone6,1", "iPhone6,2":                  return "iPhone 5s"
            case "iPhone7,2":                               return "iPhone 6"
            case "iPhone7,1":                               return "iPhone 6 Plus"
            case "iPhone8,1":                               return "iPhone 6s"
            case "iPhone8,2":                               return "iPhone 6s Plus"
            case "iPhone9,1", "iPhone9,3":                  return "iPhone 7"
            case "iPhone9,2", "iPhone9,4":                  return "iPhone 7 Plus"
            case "iPhone8,4":                               return "iPhone SE"
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
                
            // IPAD
            case "iPad4,1", "iPad4,2", "iPad4,3":           return "iPad Air"
            case "iPad5,3", "iPad5,4":                      return "iPad Air 2"
            case "iPad6,11", "iPad6,12":                    return "iPad 5"
            case "iPad7,5", "iPad7,6":                      return "iPad 6"
            case "iPad4,4", "iPad4,5", "iPad4,6":           return "iPad Mini 2"
            case "iPad4,7", "iPad4,8", "iPad4,9":           return "iPad Mini 3"
            case "iPad5,1", "iPad5,2":                      return "iPad Mini 4"
            case "iPad6,3", "iPad6,4":                      return "iPad Pro (9.7-inch)"
            case "iPad6,7", "iPad6,8":                      return "iPad Pro (12.9-inch)"
            case "iPad7,1", "iPad7,2":                      return "iPad Pro (12.9-inch) (2nd generation)"
            case "iPad7,3", "iPad7,4":                      return "iPad Pro (10.5-inch)"
            case "iPad8,1", "iPad8,2", "iPad8,3", "iPad8,4":return "iPad Pro (11-inch)"
            case "iPad8,5", "iPad8,6", "iPad8,7", "iPad8,8":return "iPad Pro (12.9-inch) (3rd generation)"
            case "iPad8,11", "iPad8,12":                    return "iPad Pro (12.9-inch) (4th generation)"
                
            // SIMULATOR
            case "i386", "x86_64":                          return "Simulator \(mapToDevice(identifier: ProcessInfo().environment["SIMULATOR_MODEL_IDENTIFIER"] ?? "iOS"))"
            default:                                        return identifier
            }
        }
        
        return mapToDevice(identifier: identifier)
    }()
}

// ------------------------------------------------------------- IPHONE NAMES -------------------------------------------------------------

public extension UIDevice {
    var isSmall: Bool {
           let devices = ["iPhone SE", "iPhone 5s", "Simulator iPhone 5s", "Simulator iPhone SE"]
           
           let d = UIDevice.modelName
           if devices.contains(d){
               return true
           } else {
               return false
           }
       }
    
    var is47: Bool {
        let small = ["iPhone 6", "iPhone 6s", "iPhone 7", "iPhone 8", "iPhone SE (2nd generation)"]
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
        let small = ["Simulator iPhone XR", "Simulator iPhone XS Max", "iPhone XS Max", "iPhone XR", "iPhone 11 Pro Max"]
        let name = UIDevice.modelName

        if small.contains(name){
            print("506 CONT")
            return true
        } else {
            return false
        }
    }
    
    var is58: Bool {
        let small = ["Simulator iPhone XS", "Simulator iPhone X", "iPhone X", "iPhone XS", "iPhone 11 Pro"]
        let name = UIDevice.modelName
        
        if small.contains(name){
            print("506 CONT")
            return true
        } else {
            return false
        }
    }
}
