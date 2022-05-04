<template>
    <header>
        <img alt="Vue logo" class="logo" src="./assets/logo.svg" width="125" height="125" />
    </header>

    <main>
        <CodeScanner @scanned="scanned"></CodeScanner>
        <div>
            Code is :{{ code }}
        </div>
        <hr />
        <div>
            successfully created: {{ success }}

        </div>

        <button @click="saveBarcode">SaveBarcode</button>

    </main>
</template>

<script setup lang="ts">
import type { Html5QrcodeResult } from "html5-qrcode/esm/core";
import { ref } from "vue";
import CodeScanner from "./components/CodeScanner.vue";


const code = ref("")
const html5QrcodeResult = ref<Html5QrcodeResult>();

const success = ref(false)

function scanned(scannedCode: string, decodedResult: Html5QrcodeResult) {
    code.value = scannedCode
    html5QrcodeResult.value = decodedResult
}


async function saveBarcode() {
    const response = await fetch("https://localhost:7027/Barcode", {
        method: "POST",
        mode: "cors",
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({
            code: code.value,
            type: html5QrcodeResult.value?.result.format?.formatName
        })
    });
    success.value = true

}

</script>

<style>
@import './assets/base.css';

#app {
    max-width: 1280px;
    margin: 0 auto;
    padding: 2rem;

    font-weight: normal;
}

header {
    line-height: 1.5;
}

.logo {
    display: block;
    margin: 0 auto 2rem;
}

a,
.green {
    text-decoration: none;
    color: hsla(160, 100%, 37%, 1);
    transition: 0.4s;
}

@media (hover: hover) {
    a:hover {
        background-color: hsla(160, 100%, 37%, 0.2);
    }
}

@media (min-width: 1024px) {
    body {
        display: flex;
        place-items: center;
    }

    #app {
        display: grid;
        grid-template-columns: 1fr 1fr;
        padding: 0 2rem;
    }

    header {
        display: flex;
        place-items: center;
        padding-right: calc(var(--section-gap) / 2);
    }

    header .wrapper {
        display: flex;
        place-items: flex-start;
        flex-wrap: wrap;
    }

    .logo {
        margin: 0 2rem 0 0;
    }
}
</style>
