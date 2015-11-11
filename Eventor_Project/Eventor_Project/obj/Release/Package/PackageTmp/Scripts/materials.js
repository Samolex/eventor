$(document).ready(function () {
    var MaterialModel = function (projectId) {
        var self = this;
        self.newMaterialTitle = ko.observable('');
        self.newMaterialAmount = ko.observable('');
        self.newMaterialProjectID = projectId;

        self.materials = ko.observableArray();

        self.addMaterial = function () {
            var newMaterial = {
                Title: self.newMaterialTitle,
                RequiredAmount: self.newMaterialAmount,
                ProjectId: self.newMaterialProjectID
            }
            ajaxReq('/Projects/AddMaterial', 'POST', newMaterial,
                function cb(data, jqXHR, textStatus, errorThrown) {
                    if (data != null) {
                        self.materials.push(data);
                        self.newMaterialTitle('');
                        self.newMaterialAmount('');
                    }
                    else {
                        console.log(textStatus);
                        console.log(errorThrown);
                    }
                });
        };

        self.getMaterials = function () {
            ajaxReq('/Projects/GetMaterials', 'GET', { projectId: projectId },
                function cb(data, jqXHR, textStatus, errorThrown) {
                    if (data != null) {
                        debugger;
                        data.forEach(function (item) {
                            self.materials.push(item);
                        });
                    }
                    else {
                        console.log(jqXHR);
                        console.log(textStatus);
                        console.log(errorThrown);
                    }
                });
        };

        self.removeMaterial = function (material) {
            ajaxReq('/Projects/DeleteMaterial', 'POST', { materialId: material.MaterialId },
                function cb(data, jqXHR, textStatus, errorThrown) {
                    if (data != null) {
                        self.materials.remove(material);
                    }
                    else {
                        console.log(jqXHR);
                        console.log(textStatus);
                        console.log(errorThrown);
                    }
                });
        };
    };

    var CustomerModel = function (projectId) {
        var self = this;
        self.newCustomerRole = ko.observable('');
        self.newCustomerDescription = ko.observable('');
        self.newCustomerMaxCount = ko.observable('');
        self.newCustomerMinCount = ko.observable('');
        self.newCustomerProjectId = projectId;

        self.customers = ko.observableArray();

        self.addCustomer = function () {
            var newCustomer = {
                Role: self.newCustomerRole,
                Description: self.newCustomerDescription,
                MaxCount: self.newCustomerMaxCount,
                MinCount: self.newCustomerMinCount,
                ProjectId: self.newCustomerProjectId
            }
            debugger;
            ajaxReq('/Projects/AddCustomer', 'POST', newCustomer,
                function cb(data, jqXHR, textStatus, errorThrown) {
                    if (data != null) {
                        self.customers.push(data);
                        self.newCustomerRole('');
                        self.newCustomerDescription('');
                        self.newCustomerMaxCount('');
                        self.newCustomerMinCount('');
                    }
                    else {
                        console.log(textStatus);
                        console.log(errorThrown);
                    }
                });
        };

        self.getCustomers = function () {
            ajaxReq('/Projects/GetCustomers', 'GET', { projectId: projectId },
                function cb(data, jqXHR, textStatus, errorThrown) {
                    if (data != null) {
                        data.forEach(function (item) {
                            self.customers.push(item);
                        });
                    }
                    else {
                        console.log(jqXHR);
                        console.log(textStatus);
                        console.log(errorThrown);
                    }
                });
        };

        self.removeCustomer = function (customer) {
            ajaxReq('/Projects/DeleteCustomer', 'POST', { customerId: customer.CustomerId },
                function cb(data, jqXHR, textStatus, errorThrown) {
                    if (data != null) {
                        self.customers.remove(customer);
                    }
                    else {
                        console.log(jqXHR);
                        console.log(textStatus);
                        console.log(errorThrown);
                    }
                });
        };
    }

    var OrganizerModel = function (projectId) {
        var self = this;
        self.newOrganizerName = ko.observable('');
        self.newOrganizerDescription = ko.observable('');
        self.newOrganizerRequiredCount = ko.observable('');
        self.newOrganizerProjectId = projectId;

        self.organizers = ko.observableArray();

        self.addOrganizer = function () {
            var newOrganizer = {
                Name: self.newOrganizerName,
                Description: self.newOrganizerDescription,
                RequiredCount: self.newOrganizerRequiredCount,
                ProjectId: self.newOrganizerProjectId
            }
            debugger;
            ajaxReq('/Projects/AddOrganizer', 'POST', newOrganizer,
                function cb(data, jqXHR, textStatus, errorThrown) {
                    if (data != null) {
                        console.log(data);
                        self.organizers.push(data);
                        self.newOrganizerName('');
                        self.newOrganizerDescription('');
                        self.newOrganizerRequiredCount('');
                    }
                    else {
                        console.log(textStatus);
                        console.log(errorThrown);
                    }
                });
        };

        self.getOrganizers = function () {
            ajaxReq('/Projects/GetOrganizers', 'GET', { projectId: projectId },
                function cb(data, jqXHR, textStatus, errorThrown) {
                    if (data != null) {
                        data.forEach(function (item) {
                            self.organizers.push(item);
                        });
                    }
                    else {
                        console.log(jqXHR);
                        console.log(textStatus);
                        console.log(errorThrown);
                    }
                });
        };

        self.removeOrganizer = function (organizer) {
            ajaxReq('/Projects/DeleteOrganizer', 'POST', { organizerId: organizer.OrganizerId },
                function cb(data, jqXHR, textStatus, errorThrown) {
                    if (data != null) {
                        self.organizers.remove(organizer);
                    }
                    else {
                        console.log(jqXHR);
                        console.log(textStatus);
                        console.log(errorThrown);
                    }
                });
        };
    }

    var InventoryModel = function () {
        var self = this;
        var projectId = getQueryVariable('projectId');
        self.materialModel = new MaterialModel(projectId);
        self.customerModel = new CustomerModel(projectId);
        self.organizerModel = new OrganizerModel(projectId);
    }
    var viewModel = new InventoryModel();
    ko.applyBindings(viewModel);

});