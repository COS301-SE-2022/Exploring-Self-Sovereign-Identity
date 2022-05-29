export class LoginCommand {
    public constructor(hash: string) {
        this.hash = hash;
    }

    private hash: string;
}