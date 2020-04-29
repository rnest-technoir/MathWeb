
let calculateFunctionExampleModule = angular.module('calculateFunctionExampleModule', []);

let domain = [];
let x = 0;
let domainBox = d3.select('#domain-box');
let xyBox = d3.select('#xy-box');

let points = [

    { px: 0, py: 0 },
   
];

let cf = new CalculateFunction(points);

calculateFunctionExampleModule.controller('calculateFunctionExampleCtrl', function ($scope) {

    cf.drawPlot('#target', 600, 600, true);
    
});

calculateFunctionExampleModule.controller('handleDomainList', function ($scope, $http) {

    $scope.number = null;
    $scope.xlist = null;

    $scope.$watch('number', function () {
        x = $scope.number;
    });

    $scope.addToDomain = function () {

        if (!isNaN(x) && x !== '' && x !== null && x !== undefined) {

            x = parseFloat(x);

            if (x === 4 || x === -4) {
                toastr.error('Liczby 4 oraz -4 nie należą do dziedziny funkcji');
                x = null;
                $('#x-input').val('');
                return ;
            }

            domain.push(parseFloat(x));
            domainBox.html(domain.toString());

            $http({
                method: 'POST',
                url: '/Function/CalculateFunctionExampleData',
                data: JSON.stringify(domain),
                dataType: 'json',
                headers: { "Content-Type": "application/json" }
            }).then(function successCallback(response) {

                if (response.data.length == 0)
                    response.data = [{ px: 0, py: 0 }];

                cf.clearAll();
                cf.clearLayout();
                
                cf.setPoints(response.data);
                cf.setDefaults();

                cf.drawLayout();
                cf.drawFunction();
                cf.drawPlotLines();
                cf.drawXY();

                xyBox.selectAll('div.xy-elem').remove();

                response.data.map(function (cv, i, arr) {
                    xyBox.append('div').attr('class', 'xy-elem').html("(" + cv.px.toFixed(2) + ", " + cv.py.toFixed(2) + ")");
                });

                toastr.success('Wartość ' + x + ' została dodana');
                x = null;
            }, function errorCallback(response) {
                    console.log(response);
                    toastr.error('Wystąpił błąd!');
            });

        }
        $('#x-input').val('');
    };

    $scope.removeFromDomain = function () {

        if (domain.length > 0) {

            x = domain.pop();
            domainBox.html(domain.toString());

            $http({
                method: 'POST',
                url: '/Function/CalculateFunctionExampleData',
                data: JSON.stringify(domain),
                dataType: 'json',
                headers: { "Content-Type": "application/json" }
            }).then(function successCallback(response) {

                cf.clearAll();
                cf.clearLayout();

                if (response.data.length == 0)
                    response.data = [{ px: 0, py: 0 }];

                cf.setPoints(response.data);
                cf.setDefaults();

                cf.drawLayout();
                cf.drawFunction();
                cf.drawPlotLines();
                cf.drawXY();

                xyBox.selectAll('div.xy-elem').remove();

                response.data.map(function (cv, i, arr) {
                    xyBox.append('div').attr('class', 'xy-elem').html("(" + cv.px.toFixed(2) + ", " + cv.py.toFixed(2) + ")");
                });

                toastr.success('Wartość ' + x + ' została usunięta');

            }, function errorCallback(response) {
                    console.log(response);
                    toastr.error('Wystąpił błąd!');
            });

        }
        

    };

    

});