<template>
    <div class="about">
        <h1>This the photo gallery page {{ tipoUsuario }}</h1>
    </div>
</template>

<style lang="scss">
.about {
    text-align: center;
}
</style>

<script>
export default {
    props: {
        tipoUsuario: {
            type: String,
        },
    },
};
</script>
