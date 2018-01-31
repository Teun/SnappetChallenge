interface SammyContext {
    params: any;
}

interface SammyInst {
    route(verb: string, path: string, callback: () => any): void;
    route(verb: string, path: string, callback: (context: SammyContext) => any): void;
    get(path: string, callback: () => any): void;
    get(path: RegExp, callback: () => any): void;
    get(path: string, callback: (context: SammyContext) => any): void;
    get(path: RegExp, callback: (context: SammyContext) => any): void;
    post(path: string, callback: () => any): void;
    post(path: RegExp, callback: () => any): void;
    post(path: string, callback: (context: SammyContext) => any): void;
    post(path: RegExp, callback: (context: SammyContext) => any): void;
    put(path: string, callback: () => any): void;
    put(path: RegExp, callback: () => any): void;
    put(path: string, callback: (context: SammyContext) => any): void;
    put(path: RegExp, callback: (context: SammyContext) => any): void;
    del(path: string, callback: () => any): void;
    del(path: RegExp, callback: () => any): void;
    del(path: string, callback: (context: SammyContext) => any): void;
    del(path: RegExp, callback: (context: SammyContext) => any): void;
    setLocation(path: string): void;
    run(initPath: string): void;
}

interface SammyStatic {
    (): SammyInst;
    (selector: string): SammyInst;
    (appInit: () => void): SammyInst;
    (selector: string, appInit: () => void): SammyInst;
}

declare module "sammy" {
    export = Sammy;
}

declare var Sammy: SammyStatic;