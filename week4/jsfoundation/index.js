const form = document.querySelector('form');
let output = document.querySelector('#output');

const addBtn = document.querySelector('#add');
const subBtn = document.querySelector('#subtract');
const multBtn = document.querySelector('#multiply');
const divBtn = document.querySelector('#divide');
const modBtn = document.querySelector('#modulus');

let isActionSet = false;

form.addEventListener('submit', function(event) {
    
    event.preventDefault();
    // Grab value of first number
    const firstNumber = event.target.elements['numberOne'].value;

    // Grab value of second number
    const secondNumber = event.target.elements['numberTwo'].value;

    console.log(firstNumber);
    console.log(secondNumber);

    // Display output on the screen
    let result = document.createElement('p');
    let calculationResult = Number(firstNumber) + Number(secondNumber);
    result.textContent = `Result: ${calculationResult}`;

    output.appendChild(result);
})

// Function to change button color
function ChangeColor(event){
    event.preventDefault();

    const clickedButton = event.target;
    clickedButton.style.backgroundColor = "red";
}


/*
// Old (before ES6) way
function selectAction(action){
    // Your code goes here
}

// New way
const selectAction = (firstNumber, secondNumber) => {
    return something;
}

*/