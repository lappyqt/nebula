export default () => ({
    discordURI: "https://discord.com/oauth2/authorize?client_id=1253405458111397959&response_type=code&redirect_uri=http%3A%2F%2Flocalhost%3A5234%2Fauth%2Fdiscord&scope=identify+email",
    
    redirectToDiscord(): void {
        location.assign(this.discordURI);
    }
});