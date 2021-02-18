module Gigasecond
open System

let add (beginDate: DateTime):DateTime = 
    beginDate.AddSeconds(float 1_000_000_000.0)