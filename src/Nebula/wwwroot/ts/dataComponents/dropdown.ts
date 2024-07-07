export default () => ({
    visible: false,

    toggle(): void {
        this.visible = !this.visible;
    },

    clickOutside(): void {
        this.visible = false;
    },

    signOut(): void {
        location.assign("/auth/signout");
    }
});