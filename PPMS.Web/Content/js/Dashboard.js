new Chart(document.getElementById("doughnut-chart-Tanker1"), {
    type: 'doughnut',
    data: {
        labels: ["Left", "Used"],
        datasets: [
            {
                label: "Tanker 1- Diesel",
                backgroundColor: ["#33cc33", "#ff1a1a"],
                data: [40, 60]
            }
        ]
    },
    options: {
        title: {
            display: true,
            text: 'Tanker 1 status'
        }
    }
});

new Chart(document.getElementById("doughnut-chart-Tanker2"), {
    type: 'doughnut',
    data: {
        labels: ["Left", "Used"],
        datasets: [
            {
                label: "Tanker 2- Petrol XP",
                backgroundColor: ["#33cc33", "#ff1a1a"],
                data: [60, 40]
            }
        ]
    },
    options: {
        title: {
            display: true,
            text: 'Tanker 2 status'
        }
    }
});

new Chart(document.getElementById("doughnut-chart-Tanker3"), {
    type: 'doughnut',
    data: {
        labels: ["Left", "Used"],
        datasets: [
            {
                label: "Tanker 3- Petrol HSD",
                backgroundColor: ["#33cc33", "#ff1a1a"],
                data: [70, 30]
            }
        ]
    },
    options: {
        title: {
            display: true,
            text: 'Tanker 3 status'
        }
    }
});

