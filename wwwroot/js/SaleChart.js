// SaleChart.js

function formatDate(date) {
    let month = date.getMonth() + 1; // Months are zero-based
    let day = date.getDate();
    
    // Add leading zero if necessary
    if (month < 10) month = '0' + month;
    if (day < 10) day = '0' + day;
    
    return month + '/' + day;
}
  
// Get today's date
const today = new Date();
  
// Create an array to hold the dates
const dateList = [];
  
// Loop for the last 7 days
for (let i = 7; i > 0; i--) {
    // Calculate the date
    const date = new Date();
    date.setDate(today.getDate() - i + 1);

    // Format the date and add to the list
    dateList.push(formatDate(date));
}

new Chart(document.getElementById("line-chart"), {
    type: 'line',
    data: {
        labels: dateList,
        datasets: [
            { 
                data: [86, 114, 106, 106, 107, 111, 133],
                backgroundColor: "#695CFE",
                borderColor: "#695CFE",
                fill: false,
            }, 
        ]
    },
    options: {
        maintainAspectRatio: false,
        scales: {
            x: {
                grid: {
                    display: false
                },
                border: {
                    display: false
                }
            },
            y: {
                ticks: {
                    stepSize: 20
                },
                grid: {
                    display: false
                },
                border: {
                    display: false
                }
            }
        },
        title: {
            display: true,
        },
        plugins: {
            title: {
                display: true,
                text: `매출/판매 통계`,
                color: "#000",
                font: {
                    family: "Noto Sans KR",
                    size: 20,
                    weight: 600,
                },
                align: 'start',
                padding: {
                    bottom: 30,
                }
            },
            legend: {
                display: false
            },
            tooltop: {
                enabled: false,
            }
        },
        interaction: {
            mode: 'nearest'
        }
    }
});

Chart.update();
