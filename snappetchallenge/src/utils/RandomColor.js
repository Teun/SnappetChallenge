export default function () {
    let letters = '0123456789ABCDEF';
    let color = '#';
    let i;
    for (i = 0; i < 6; i+=1) {
        color += letters[Math.floor(Math.random() * 16)];
    }
    return color;
}
