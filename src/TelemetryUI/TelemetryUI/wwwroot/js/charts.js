// Import Chart.js if not already included in your HTML

let lineChart = null;
let pieChart = null;

function initializeCharts(lineChartData, pieChartData) {
    // Cleanup existing charts
    if (lineChart) {
        lineChart.destroy();
    }
    if (pieChart) {
        pieChart.destroy();
    }

    // Initialize Line Chart
    const lineCtx = document.getElementById('chartline');
    if (lineCtx) {
        lineChart = new Chart(lineCtx, {
            type: 'line',
            data: lineChartData,
            options: {
                responsive: true,
                maintainAspectRatio: false,
                scales: {
                    y: {
                        beginAtZero: true,
                        grid: {
                            color: 'rgba(0, 0, 0, 0.1)'
                        }
                    },
                    x: {
                        grid: {
                            color: 'rgba(0, 0, 0, 0.1)'
                        }
                    }
                },
                plugins: {
                    legend: {
                        position: 'top',
                        labels: {
                            usePointStyle: true,
                            padding: 20
                        }
                    },
                    tooltip: {
                        backgroundColor: 'rgba(0, 0, 0, 0.7)',
                        padding: 12,
                        usePointStyle: true
                    }
                }
            }
        });
    }

    // Initialize Pie Chart
    const pieCtx = document.getElementById('chartpie');
    if (pieCtx) {
        pieChart = new Chart(pieCtx, {
            type: 'pie',
            data: pieChartData,
            options: {
                responsive: true,
                maintainAspectRatio: false,
                plugins: {
                    legend: {
                        position: 'right',
                        labels: {
                            usePointStyle: true,
                            padding: 20
                        }
                    },
                    tooltip: {
                        backgroundColor: 'rgba(0, 0, 0, 0.7)',
                        padding: 12
                    }
                }
            }
        });
    }
}