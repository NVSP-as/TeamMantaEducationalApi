// URL of the API endpoint
const apiUrl = "https://localhost:7142/Operations";

// Function to fetch and display operations data
async function fetchOperations() {
  try {
    const response = await fetch(apiUrl);
    if (!response.ok) throw new Error("Failed to fetch operations.");

    const data = await response.json();
    displayOperations(data);
  } catch (error) {
    console.error("Error:", error);
  }
}

// Function to display operations grouped by type
function displayOperations(operations) {
  const queueContainer = document.getElementById("queue").querySelector(".cards");
  const inProgressContainer = document.getElementById("in-progress").querySelector(".cards");
  const doneContainer = document.getElementById("done").querySelector(".cards");
  operations.forEach(operation => {
    const card = document.createElement("div");
    card.className = "card";
    card.innerHTML = `
            <h3>${operation.name}</h3>
            <p><strong>Description:</strong> ${operation.description}</p>
            <p><strong>Priority:</strong> <span class="priority">${operation.priority}</span></p>
            <p><strong>Assigned To:</strong> ${operation.assignedTo}</p>
            <p><strong>Status:</strong> ${operation.status}</p>
            <p><strong>Progress:</strong> <span class="progress">${operation.progressPercentage}%</span></p>
            <p><strong>Created Date:</strong> ${new Date(operation.createdDate).toLocaleString()}</p>
            <p><strong>Estimated Completion:</strong> ${new Date(operation.estimatedCompletionTime).toLocaleString()}</p>
        `;

    if (operation.type === "Queue") {
      queueContainer.appendChild(card);
    } else if (operation.type === "InProgress") {
      inProgressContainer.appendChild(card);
    } else if (operation.type === "Done") {
      doneContainer.appendChild(card);
    }
  });
}

window.onload = fetchOperations;
