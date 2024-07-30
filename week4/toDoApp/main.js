let ToDoList = [];

const form = document.querySelector('form');

// Create output for the results
const main = document.querySelector("main");
const output = document.createElement("section");
const unorderedList = document.createElement("ul");

main.appendChild(output);

if(ToDoList.length == 0)
{
    output.innerHTML = "No tasks yet!";
}
else
{
    output.appendChild(unorderedList);
}

form.addEventListener("submit", (e) => {
    e.preventDefault();

    const taskDescription = document.querySelector('#taskDescription').value;
    const dueDate = document.querySelector('#dueDate').value;

    let myTask = {
        description: taskDescription,
        dueDate: dueDate
    };

    ToDoList.push(myTask);

    output.innerHTML ="";
    ToDoList.forEach(task => {
        const newTask = document.createElement("li");
        newTask.innerHTML = `${task.description} due date: ${task.dueDate}`;
        output.appendChild(newTask);
    })
})