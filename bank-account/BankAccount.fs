module BankAccount

let mkBankAccount() = 
    {
        let balance = 0.0m
        let isOpen = true
        let updateBalance = (amount: decimal) => {
            balance = balance + amount
            return balance
        }
        let getBalance = () => {
            return balance
        }
        let openAccount = () => {
            isOpen = true
            return account
        }
        let closeAccount = () => {
            isOpen = false
            return account
        }
        let account = {
            getBalance: getBalance,
            updateBalance: updateBalance,
            openAccount: openAccount,
            closeAccount: closeAccount
        }
        return account
    }

let openAccount account = failwith "You need to implement this function."

let closeAccount account = failwith "You need to implement this function."

let getBalance account = failwith "You need to implement this function."

let updateBalance change account = failwith "You need to implement this function."