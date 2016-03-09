var module = angular.module("mycustomerApp", []);
module.controller("customerCtrl", function ($scope, $http) {
    
    $scope.setList();

    $scope.edit = true;
    $scope.error = false;
    $scope.incomplete;

    //Edit 
    $scope.editCustomer = function (id) {
        if (id == 'new') {
            $scope.edit = true;
            $scope.incomplete = true;
            $scope.ID = 0;
            $scope.Name = '';
            $scope.Phone = '';
            $scope.Address = '';
            $scope.Email = '';
        } else {
            $scope.edit = false;
            $scope.ID = $scope.Customer[id].ID;
            $scope.Name = $scope.Customer[id].Name.trim();
            $scope.Phone = $scope.Customer[id].Phone.trim();
            $scope.Address = $scope.Customer[id].Address.trim();
            $scope.Email = $scope.Customer[id].Email.trim();
            $("#idEmail").val($scope.Email.trim());
            $scope.incomplete = false;
        }
    };
    //update or add new 
    $scope.PostCustomer = function () {
        $post("api/customerapi",
                $("#cusForm").serialize(),
                function (value) {
                    $scope.setList();
                    alert("Saved successfully");
                }
                , "json"
            )

    };

    $scope.delCustomer = function (id) {
        if(confirm("wanna delete?"))
        {
            $http.delete("/api/customerapi/" + id).success(function ()
            {
                alert("deleted");
                $scope.setList();
            }).error(function ()
            {
                alert("Error");
            })
        }
    }
    $scope.setList = function ()
    {
        $http.get("/api/customerapi").success(function (response) {
            $scope.customers = response;
        })
    }
});