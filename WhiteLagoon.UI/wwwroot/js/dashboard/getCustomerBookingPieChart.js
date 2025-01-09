$(document).ready(function () {
    loadCustomerBookingPieChart();
});
function loadCustomerBookingPieChart() {
    $.ajax({
        url: "/Dashboard/GetBookingPieChartData",
        type: 'GET',
        dataType: 'json',
        success: function (data) {

            loadPieChart("customerBookingsPieChart", data);
        }
    });
}
function loadPieChart(id, data) {
    var chartColors = getChartColorsArray(id);
    var options = {
        colors: chartColors,
        series: data.series,
        labels: data.labels,
        chart: {
            width: 380,
            type: 'pie',
        },
        stroke: {
            show: false
        },
        legend: {
            position: 'bottom',
            horizontalAlign: 'center',
            labels: {
                colors: "#fff",
                useSeriesColors: true
            },
        },
    };
    var chart = new ApexCharts(document.querySelector("#" + id), options);
    chart.render();
}