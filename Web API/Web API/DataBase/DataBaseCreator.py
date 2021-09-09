import json

def Creator():
    roleCreator()
    ClientCreator()
    accountCreator()
    cardsCreator()

def roleCreator():
    role = {}
    role['roles'] = []
    role['roles'].append({
        'roleName': 'work1',
        'roleDescription': 'roleDescription1'
    })

    role['roles'].append({
        'roleName': 'work2',
        'roleDescription': 'roleDescription2'
    })

    role['roles'].append({
        'roleName': 'work3',
        'roleDescription': 'roleDescription3'
    }) 

    with open('Roles.json', 'w') as outfile:
        json.dump(role, outfile)

def ClientCreator():
    client = {}
    client['clients'] = []
    client['clients'].append({
        'clientName': 'client1',
        'clientId': 'clientid1',
        'clientAddress': 'clientAddress1',
        'clientPhone': 'clientPhone1',
        'clientSalary': 'clientSalary1',
        'clientType': 'clientType1'
    })

    client['clients'].append({
        'clientName': 'client2',
        'clientId': 'clientid2',
        'clientAddress': 'clientAddress2',
        'clientPhone': 'clientPhone2',
        'clientSalary': 'clientSalary2',
        'clientType': 'clientType2'
    })

    client['clients'].append({
        'clientName': 'client3',
        'clientId': 'clientid3',
        'clientAddress': 'clientAddress3',
        'clientPhone': 'clientPhone3',
        'clientSalary': 'clientSalary3',
        'clientType': 'clientType3'
    })

    client['clients'].append({
        'clientName': 'client4',
        'clientId': 'clientid4',
        'clientAddress': 'clientAddress4',
        'clientPhone': 'clientPhone4',
        'clientSalary': 'clientSalary4',
        'clientType': 'clientType4'
    })

    client['clients'].append({
        'clientName': 'client5',
        'clientId': 'clientid5',
        'clientAddress': 'clientAddress5',
        'clientPhone': 'clientPhone5',
        'clientSalary': 'clientSalary5',
        'clientType': 'clientType5'
    })

    with open('Clients.json', 'w') as outfile:
        json.dump(client, outfile)

def accountCreator():
    account = {}
    account['accounts'] = []
    account['accounts'].append({
        'accountNumber': 'accountNumber1',
        'accountDescription': 'accountDescription1',
        'accountCurrency': 'accountCurrency1',
        'accountType': 'accountType1',
        'accountOwner': 'accountOwner1'
    })
    account['accounts'].append({
        'accountNumber': 'accountNumber2',
        'accountDescription': 'accountDescription2',
        'accountCurrency': 'accountCurrency2',
        'accountType': 'accountType2',
        'accountOwner': 'accountOwner2'
    })
    account['accounts'].append({
        'accountNumber': 'accountNumber3',
        'accountDescription': 'accountDescription3',
        'accountCurrency': 'accountCurrency3',
        'accountType': 'accountType3',
        'accountOwner': 'accountOwner3'
    })
    account['accounts'].append({
        'accountNumber': 'accountNumber4',
        'accountDescription': 'accountDescription4',
        'accountCurrency': 'accountCurrency4',
        'accountType': 'accountType4',
        'accountOwner': 'accountOwner4'
    })
    account['accounts'].append({
        'accountNumber': 'accountNumber5',
        'accountDescription': 'accountDescription5',
        'accountCurrency': 'accountCurrency5',
        'accountType': 'accountType5',
        'accountOwner': 'accountOwner'
    })

    with open('Accounts.json', 'w') as outfile:
        json.dump(account, outfile)

def cardsCreator():
    card = {}
    card['cards'] = []
    card['cards'].append({
        'cardNumber': 'cardNumber1',
        'cardType': 'cardType1',
        'cardExpiryDate': 'cardExpiryDate1',
        'cardSecureCode': 'cardSecureCode1',
        'cardBalance': 'cardBalance1'
    })

    card['cards'].append({
        'cardNumber': 'cardNumber2',
        'cardType': 'cardType2',
        'cardExpiryDate': 'cardExpiryDate2',
        'cardSecureCode': 'cardSecureCode2',
        'cardBalance': 'cardBalance2'
    })

    card['cards'].append({
        'cardNumber': 'cardNumber3',
        'cardType': 'cardType3',
        'cardExpiryDate': 'cardExpiryDate3',
        'cardSecureCode': 'cardSecureCode3',
        'cardBalance': 'cardBalance3'
    })

    with open('Cards.json', 'w') as outfile:
        json.dump(card, outfile)
Creator()