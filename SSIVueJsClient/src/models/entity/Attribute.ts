class Attribute {

    public constructor(id: string, name: string, value: string) {
        this.id = id;
        this.name = name;
        this.value = value;
    }

    public getId() : string {
        return this.id;
    }

    public getName() : string {
        return this.name;
    }

    public getValue() : string {
        return this.value;
    }

    private id : string;
    private name : string;
    private value : string;

}