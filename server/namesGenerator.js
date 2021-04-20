const fs = require('fs');
const ids = [
    40281, 40282, 40285, 68421,
    40284, 40273, 40278, 40267,
    40271, 40276, 40275, 40274,
    40272, 40270, 40286, 40277,
    40268, 40279, 40280, 40283
];
const names = [
    "Huig Nieuwkamp",
    "Mechiel te Wiereke",
    "Joren Wetering",
    "Pier Weldink",
    "Karst-Jan op Sonnebeld",
    "Peter-jan Nijdekker",
    "Egbert Kromhof",
    "Peter-jan Teijsselink",
    "Berg Maas",
    "Wil van Tubbergh",
    "Jelle Wieringa",
    "Jurriaan Veldhuizen",
    "Jop Kool",
    "Hein Hazelekke",
    "Stijn Kraaijenbrink",
    "Youri Meerman",
    "Basten Dwars",
    "Sjef Wilmes",
    "Lodewijk Coninenbelt",
    "Leendert Geusendam"
];

const students = []

ids.forEach((el, index) => {
    students.push({
        id: el,
        name: names[index]
    })
});
fs.writeFile('data/students.json', JSON.stringify(students), () => {});