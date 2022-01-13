import { createApp } from 'vue';
import App from './App.vue';
import './styles';

function domReady(callback: () => void) {
    document.readyState === 'interactive' || document.readyState === 'complete'
        ? callback()
        : document.addEventListener('DOMContentLoaded', callback);
}

function init(){
    var app = createApp({
        rootComponent: App
    });

    app.mount('#app');
}

domReady(init);
