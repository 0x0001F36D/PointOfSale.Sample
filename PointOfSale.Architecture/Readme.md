# 🍓Point of Sale - Architecture🍓
## 🍓 ***About*** 🍓
- 這是一套物件導向實作範例 ***(使用 Pos System 做為題材)***
- 內含以下設計模式 ***(Design Pattern)***
  1. 單例模式 ***(Singleton Pattern)***
  2. 享元模式 ***(Flyweight Pattern)***
  3. 建造者模式 ***(Builder Pattern)***
  4. 裝飾者模式 ***(Decorator Pattern)***
  5. 橋接模式 ***(Bridge Pattern)***
  6. 模板模式 ***(Template Pattern)***
## 🍓 ***Comment*** 🍓
### 命名空間介紹
---
- ### ***PointOfSale.Contents.Service.Infrastructure***
  ##### 這個命名空間底下包含所有服務類別共用的基底類別
  1. ***Guest*** 類別 : 提供實作來賓之基本所需資料
  2. ***OrderType*** 抽象類別 : 用以提供各種點餐方式之基本服務
  3. ***Report*** 類別 : 提供單日報表之基本統計資料分析 ***(i.e.: 單日熱門飲料排行, 單日飲料添加物排行)***
---
- ### ***PointOfSale.Contents.Service***
  ##### 這個命名空間底下包含所有具有服務性質的類別
  1. ***Delivery*** 類別 : 繼承自 ***OrderType*** 抽象類別，用以實現 __外送飲料__ 之服務
  2. ***Takeaway*** 類別 : 繼承自 ***OrderType*** 抽象類別，用以實現 __現場點取飲料__ 之服務
  3. ***Reservation*** 類別 : 繼承自 ***OrderType*** 抽象類別，用以實現 __電話預約，現場領取飲料__ 之服務
  4. ***Site*** 類別 : 主要的服務類別，由管理員提供一組密碼並透過呼叫 ***Site.Launch()*** 靜態方法產生 ***POS*** 系統主機連線服務初始化後方可呼叫 ***Site.Order()*** 多載方法 與 ***Site.Cancel()*** 方法進行點餐及取消點餐，透過 ***Site.Settlement()*** 可以產生 ***Report*** 類別之單日報表
---
- ### ***PointOfSale.Contents.Common***
  ##### 這個命名空間底下包含所有 **Contents** 命名空間下共用的類別
  1. ***AdditiveProvider*** 類別 : 物件提供者類別，使用 ***Reflection*** 技術動態載入組件中所有實作自 ***IAdditive*** 介面之添加物類別並初始化儲存於記憶體中，可使用 ***AdditiveProvider.Context.GetInstanse\<TAdditive\>() where TAdditive : IAdditive*** 或 ***AdditiveProvider.Context.GetInstanse()*** 方法取得存放於記憶體中的共用物件

        p.s : 此類別實作了 ***單例設計模式*** 及 ***享元設計模式*** 
  2. ***BeverageProvider*** 類別 : 物件提供者類別，使用 ***Reflection*** 技術動態取得組件中所有實作自 ***IBeverage*** 介面之飲品類別，可於呼叫 ***BeverageProvider.Context.CreateInstanse\<TBeverage\>() where TBeverage : IBeverage*** 或 ***BeverageProvider.Context.CreateInstanse()*** 方法後產生實體化之物件

        p.s : 此類別實作了 ***單例設計模式***
  3. ***BeverageHelper*** 靜態類別 : 提供對 ***IBeverage 介面*** 的擴充功能支援
  4. ***PosException*** 類別 : 主要的例外類別，提供所有 **Contents** 命名空間下例外訊息的封裝
---
- ### ***PointOfSale.Contents.Beverage.Infrastructure***
  ##### 這個命名空間底下包含所有飲品類別共用的基底介面、列舉及類別
  1. ***IBeverage*** 介面 : 提供所有飲品類別的共同屬性及方法
  2. ***BeverageBase*** 抽象類別 : 實作 ***IBeverage*** 介面，用以提供各式飲品類別之基本方法
  3. ***Temperature*** 列舉 : 溫度選擇
  4. ***SweetnessLevel*** 列舉 : 甜度選擇
  5. ***AmountOfIce*** 列舉 : 冰量選擇
  6. ***Size*** 列舉 : 容量選擇
---
- ### ***PointOfSale.Contents.Beverage.Items***
  ##### 這個命名空間底下包含所有實作 ***IBeverage*** 介面之飲品類別 (由於數量較多且較無舉例價值，故只挑幾個講)
  1. ***BlackTea*** 類別 : 繼承自 ***BeverageBase*** 類別之基本飲品類別 ***(故屬於 PointOfSale.Contents.Beverage.Items.Basic 命名空間)***
  2. ***MilkTea*** 類別 : 繼承自 ***BlackTea*** 類別之混合飲品類別 ***(故屬於 PointOfSale.Contents.Beverage.Items.Mixed 命名空間)*** ，其覆寫了 ***BlackTea.Price*** 屬性
  3. ***Ovaltine*** 類別 : 繼承自 ***BeverageBase*** 類別之特殊飲品類別 ***(故屬於 PointOfSale.Contents.Beverage.Items.Special 命名空間)*** ，其覆寫了 ***BeverageBase.Price*** 屬性
---
- ### ***PointOfSale.Contents.Additive.Infrastructure***
  ##### 這個命名空間底下包含所有添加物類別共用的基底介面、列舉及類別
  1. ***IAdditive*** 介面 : 提供所有添加物類別的共同屬性及方法
  2. ***AdditiveBase*** 抽象類別 : 實作 ***IAdditive*** 介面，用以提供各式添加物類別之基本方法
---
- ### ***PointOfSale.Contents.Additive.Items***
  ##### 這個命名空間底下包含所有實作 ***IAdditive*** 介面之添加物類別 (由於數量較多且較無舉例價值，故只舉兩個例子)
  1. ***Pearl*** 類別 : 繼承自 ***AdditiveBase*** 類別之基本添加物類別 
  2. ***CoconutJelly*** 類別 : 繼承自 ***AdditiveBase*** 類別之基本添加物類別
---
## 🍓 ***Class Diagram*** 🍓
![Architecture](/Architecture.png)

## 🍓 ***Author*** 🍓
[***Viyrex***][Author]
## 🍓 ***License*** 🍓
[***Apache 2.0***][License]

[Author]:https://github.com/0x0001F36D
[License]:https://github.com/0x0001F36D/PointOfSale.Sample/blob/master/PointOfSale.Architecture/License