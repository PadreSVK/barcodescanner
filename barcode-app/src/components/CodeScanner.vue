<template>
    <div id="qr-code-full-region"></div>
</template>

<script setup lang="ts">
import { onMounted } from "vue";
import { Html5QrcodeScanner } from "html5-qrcode";
import { Html5QrcodeScanType, Html5QrcodeSupportedFormats, type Html5QrcodeResult } from "html5-qrcode/esm/core";

const emit = defineEmits<{
    (e: "scanned", decodedText: string, decodedResult: Html5QrcodeResult): void
}>()


const props = defineProps({
    width: {type: Number, default: 250},
    height: {type: Number, default: 250},
})

onMounted(() => {
    const html5QrcodeScanner = new Html5QrcodeScanner('qr-code-full-region',
        {
            fps: 10, qrbox: {...props},
            supportedScanTypes: [Html5QrcodeScanType.SCAN_TYPE_CAMERA],
            formatsToSupport: [
                Html5QrcodeSupportedFormats.CODE_128,
                Html5QrcodeSupportedFormats.EAN_13,
                Html5QrcodeSupportedFormats.ITF,
                Html5QrcodeSupportedFormats.DATA_MATRIX,
                Html5QrcodeSupportedFormats.QR_CODE,
            ]
        },
        undefined);
    html5QrcodeScanner.render(onScanSuccess, undefined);
})

function onScanSuccess(decodedText: string, decodedResult: Html5QrcodeResult) {
    emit('scanned', decodedText, decodedResult);
}

</script>
