let toDoList = {
    tasks: [],
    addTask: function (task) {
        this.tasks.push(task)
    },

    removeTask: function (task) {
        this.tasks = this.tasks.filter((ele) => ele != task)
    },

    print: function () {
        this.tasks.forEach((ele) => console.log(ele));
    }
}

toDoList.addTask('football')
toDoList.addTask('basketball')
toDoList.addTask('handball')

toDoList.removeTask('football')

toDoList.print()



let users = [
    {
        name: 'mohamed',
        age: 23,
        address: {
            street: 'mohamed nagiub',
            city: 'alexandria',
            getAddress: function () {
                return this.city + ' ' + this.street;
            }
        },
        getData: function () {
            console.log(this.name, this.age, this.address.getAddress());
        }
    },
    {
        name: 'ahmed',
        age: 30,
        address: {
            street: 'el geish',
            city: 'cairo',
            getAddress: function () {
                return this.city + ' ' + this.street;
            }
        },
        getData: function () {
            console.log(this.name, this.age, this.address.getAddress());
        }
    },
    {
        name: 'sara',
        age: 27,
        address: {
            street: 'fouad st',
            city: 'alexandria',
            getAddress: function () {
                return this.city + ' ' + this.street;
            }
        },
        getData: function () {
            console.log(this.name, this.age, this.address.getAddress());
        }
    },
    {
        name: 'omar',
        age: 35,
        address: {
            street: 'tahrir',
            city: 'giza',
            getAddress: function () {
                return this.city + ' ' + this.street;
            }
        },
        getData: function () {
            console.log(this.name, this.age, this.address.getAddress());
        }
    },
    {
        name: 'nour',
        age: 22,
        address: {
            street: 'stanley',
            city: 'alexandria',
            getAddress: function () {
                return this.city + ' ' + this.street;
            }
        },
        getData: function () {
            console.log(this.name, this.age, this.address.getAddress());
        }
    }
];


users.filter((user) => user.age <= 30)
    .sort((a, b) => a.name.localeCompare(b.name))
    .forEach((user) => user.getData())
