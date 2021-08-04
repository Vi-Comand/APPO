// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
/*
Vue.createApp({
    data() {
        return {
            valueInput: '',
            needDoList: [],
            completeList: []
        };
    },
    methods: {
        load() {
            alert(1);
            this.valueInput = this.value;
            alert(this.value);
        },
        handleInput(event) {
            this.valueInput = event.target.value;
        },
        addTask() {
            if (this.valueInput === '') { return };
            this.needDoList.push({
                title: this.valueInput,
                id: Math.random()
            });
            this.valueInput = '';
        },
        doCheck(index, type) {

            if (type === 'need') {
                const completeMask = this.needDoList.splice(index, 1);
                this.completeList.push(...completeMask);
            }
            else {
                const noCompleteMask = this.completeList.splice(index, 1);
                this.needDoList.push(...noCompleteMask);
            }
        },
        removeMask(index, type) {
            const toDoList = type === 'need' ? this.needDoList : this.completeList;
            toDoList.splice(index, 1);
        }
    }
}
).mount('#app');

const Demo = {
    data() {
        
           
            return {
             1: false
           
        }
    }
}

Vue.createApp(Demo).mount('.demo')
*/

/*----------------------------------------------------дроп файл---------------------------------------------*/
var $fileInput = $('.file-input');
var $droparea = $('.file-drop-area');

// highlight drag area
$fileInput.on('dragenter focus click', function () {
    $droparea.addClass('is-active');
});

// back to normal state
$fileInput.on('dragleave blur drop', function () {
    $droparea.removeClass('is-active');
});

// change inner text
$fileInput.on('change', function () {
    var filesCount = $(this)[0].files.length;
    var $textContainer = $(this).prev();

    if (filesCount === 1) {
        // if single file is selected, show file name
        var fileName = $(this).val().split('\\').pop();
        $textContainer.text(fileName);
    } else {
        // otherwise show number of files
        $textContainer.text(filesCount + ' files selected');
    }
});


