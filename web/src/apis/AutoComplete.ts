import { AutoCompleteResponse } from "../types/AutoComplete";

export const search = async (keyword: string, type: string, count: number): Promise<AutoCompleteResponse> =>
    await fetch(`http://localhost/autocomplete?count=${count}&type=${type}&keyword=${keyword}`).then(res => res.json());
