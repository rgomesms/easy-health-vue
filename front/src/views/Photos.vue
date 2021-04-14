<template>
    <div class="about">
        <photos-gallery></photos-gallery>
    </div>
</template>

<style lang="scss">
.about {
    text-align: center;
}
</style>

<script>
import PhotosGallery from '../components/Photos/PhotosGallery';
export default {
    name: "Photos",
    components: {
        'photos-gallery': PhotosGallery,
    },
    props: {
        tipoUsuario: {
            type: String,
        },
    },
};
</script>
