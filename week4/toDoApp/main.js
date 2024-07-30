let ToDoList = [];

const form = document.querySelector('form');

// Create output for the results
const main = document.querySelector("main");
const output = document.createElement("section");
main.appendChild(output);

form.addEventListener("submit", (e) => {
    e.preventDefault();

    const taskDescription = document.querySelector('#taskDescription').value;
    const dueDate = document.querySelector('dueDate').value;

    let myTask = {
        description: taskDescription,
        dueDate: dueDate
    };

    ToDoList.push(myTask);
})