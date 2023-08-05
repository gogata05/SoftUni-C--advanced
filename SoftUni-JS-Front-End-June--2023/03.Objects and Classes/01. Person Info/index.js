// function person(firstName, lastName, age) {
//    let personDict = {};//Empty object
//     personDict.firstName = firstName;
//     personDict.lastName = lastName;
//     personDict.age = age;
//     return personDict;
// }
//   const person1 = person("Peter", "Pan", "20");
//   console.log(person1);//{firstName: 'Peter', lastName: 'Pan', age: '20'}
//   const person2 = person("George", "Smith", "18");
//   console.log(person2);//{firstName: 'George', lastName: 'Smith', age: '18'}


function person(firstName, lastName, age) {
let personDict = {};//Empty object
personDict.firstName = firstName;
personDict.lastName = lastName;
personDict.age = age;
      return personDict;
}
const person1 = person("Peter", "Pan", "20");
console.log(person1);//{firstName: 'Peter', lastName: 'Pan', age: '20'}
const person2 = person("George", "Smith", "18");
console.log(person2);//{firstName: 'George', lastName: 'Smith', age: '18'}
