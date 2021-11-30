module LuciansLusciousLasagna

// TODO: define the 'expectedMinutesInOven' binding
let expectedMinutesInOven = 40

// TODO: define the 'remainingMinutesInOven' function
let remainingMinutesInOven actual =
    expectedMinutesInOven - actual

// TODO: define the 'preparationTimeInMinutes' function

let preparationTimeInMinutes layers =
    layers * 2

// TODO: define the 'elapsedTimeInMinutes' function

let elapsedTimeInMinutes layers actual =
    (preparationTimeInMinutes layers) + actual 