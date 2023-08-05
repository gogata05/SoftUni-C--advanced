function storePhoneNumbers(input) {
    const phoneBook = {};
  
    for (const entry of input) {
      const [name, phoneNumber] = entry.split(' ');
  
      phoneBook[name] = phoneNumber;
    }
  
    let output = '';
    for (const name in phoneBook) {
      output += `${name} -> ${phoneBook[name]}\n`;
    }
  
    return output.trim();
  }

// Test the function with provided examples
const input1 = [
    'Tim 0834212554',
    'Peter 0877547887',
    'Bill 0896543112',
    'Tim 0876566344'
  ];
  
  const input2 = [
    'George 0552554',
    'Peter 087587',
    'George 0453112',
    'Bill 0845344'
  ];
  
  console.log(storePhoneNumbers(input1));
  console.log(storePhoneNumbers(input2));