$(document).ready(function () {
    var OrganisersModel = function (organisers, projectId) {
        var self = this;
        var projectId = projectId;
        self.organisers = ko.observableArray(organisers);

        self.addOrganizer = function () {
            self.organisers.push({
                RequiredCount: 0,
                Name: '',
                Description: '',
                ProjectId: projectId
            });
        };

        self.removeOrganizer = function (organizer) {
            self.organisers.remove(organizer);
        };

        self.saveOrganisers = function () {
            self.organisers(self.organisers().filter(function (item) {
                return item.RequiredCount > 0 && item.Name;
            }));
            return data = JSON.stringify(ko.toJS(self.organisers()));
        };
    };

    var MaterialsModel = function (materials ,projectId) {
        var self = this;
        self.projectId = projectId;
        self.materials = ko.observableArray(materials);

        self.addMaterial = function () {
            self.materials.push({
                Title: '',
                RequiredAmount: 0,
                ProjectId: self.projectId
            });
        };

        self.removeMaterial = function (material) {
            self.materials.remove(material);
        };

        self.saveMaterials = function () {
            self.materials(self.materials().filter(function (item) {
                return item.Title && item.RequiredAmount > 0;
            }));
            var data = JSON.stringify(ko.toJS(self.materials()));
            return data;
        };
    };

    var CustomersModel = function (customers, projectId) {
        var self = this;
        var projectId= projectId;
        self.customers = ko.observableArray(customers);

        self.addCustomer = function () {
            self.customers.push({
                MinCount: 0,
                MaxCount: 0,
                Role: '',
                Description: '',
                ProjectId: projectId
            });
        };

        self.removeCustomer = function (customer) {
            self.customers.remove(customer);
        };

        self.saveCustomers = function () {
            self.customers(self.customers().filter(function (item) {
                return item.MinCount > 0 && item.MaxCount > item.MinCount && item.Role;
            }));
            return data = JSON.stringify(ko.toJS(self.customers()));
        };

    };

    var ViewModel = function () {
        var self = this;
        var projectId = getQueryVariable("projectId");
        self.organisersModel = new OrganisersModel(null, projectId);
        self.materialsModel = new MaterialsModel(null, projectId);
        self.customersModel = new CustomersModel(null, projectId);

        self.load = function () {
            ajaxReq("/Projects/GetMaterials", "GET", { projectId: projectId },
                function (data, jqXHR, textStatus, errorThrown) {
                    if (data) {
                        data.forEach(function (item) {
                            self.materialsModel.materials.push(item);
                        });
                    }
                });
            ajaxReq("/Projects/GetOrganizers", "GET", { projectId: projectId },
                function (data, jqXHR, textStatus, errorThrown) {
                    if (data) {
                        data.forEach(function (item) {
                            self.organisersModel.organisers.push(item);
                        });
                    }
                });
            ajaxReq("/Projects/GetCustomers", "GET", { projectId: projectId },
                function (data, jqXHR, textStatus, errorThrown) {
                    if (data) {
                        data.forEach(function (item) {
                            self.customersModel.customers.push(item);
                        });
                    }
                });
        };
        self.save = function () {
            var materials = self.materialsModel.saveMaterials();
            ajaxReq("SaveMaterials", "POST", materials);
            var organisers = self.organisersModel.saveOrganisers();
            ajaxReq("SaveOrganisers", "POST", organisers);
            var customers = self.customersModel.saveCustomers();
            ajaxReq("SaveCustomers", "POST", customers);
        };
    }
    var viewModel = new ViewModel();
    viewModel.load();
    ko.applyBindings(viewModel);

});