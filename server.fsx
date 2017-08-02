#r "./packages/Suave/lib/net40/Suave.dll"
#r "./packages/FAKE/tools/FakeLib.dll"
#r "./packages/FSharp.Data/lib/net40/FSharp.Data.dll"


open System
open System.IO
open Suave
open Suave.Http
open Suave.Filters
open Suave.Operators
open Suave.Web
open Suave.RequestErrors
open FSharp.Data
open FSharp.Linq

// Print all data points

      
      type Silver = JsonProvider<"""./data/SILVER.json""">
      let silvers = Silver.GetSample()
     // let wbReq = "https://www.quandl.com/api/v1/datasets/LBMA/SILVER.json"
    //  let docAsync = Silver.AsyncLoad(wbReq)

      let sd = Silver.Load("""./data/SILVER.json""")
      
      
      let infosd = sd.Data
      let infos = silvers.Data
      let first = silvers.FromDate
      let last = silvers.ToDate
       
      type DatePrice = {
          Day: DateTime list
          Price: decimal list
      } 


      let dates = [ for each in infos -> each.DateTime ]

      let pricesusd = [ for each in infos -> each.Numbers.[0] ]
      //let prices_gbp = [ for each in infos -> each.Numbers.[1] ]

      //let prices_euro = [ for each in infos -> each.Numbers.[2] ]

            
      let c2 = printf "Data 3 %A" pricesusd
      //let hello1 (msg, index) = (Ok (sprintf "Hello World %i" bianca))
   
      let webPart =
         choose [
           path "/" >=>  (Successful.OK "Hello World")
           path "/gold" >=> (Successful.OK "Gold")
         ]

startWebServer defaultConfig webPart


