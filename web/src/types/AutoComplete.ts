export interface AutoCompleteResponse{
  items: AutoCompleteResponseItem[]
}

export interface AutoCompleteResponseItem{
  identifier: string
  type: string
}