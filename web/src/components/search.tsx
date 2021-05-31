import { useEffect, useState } from "react";
import { search } from "../apis/AutoComplete";
import { AutoCompleteResponse } from "../types/AutoComplete";

interface IProps{
    getClassReport: ((date: Date | undefined) => Promise<void>)
    getStudentReport: ((userId: number, date: Date | undefined) => Promise<void>)
}

const Search = (props : IProps) => {
    const [userId, setUserId] = useState<number>(0)
    const [date, setDate] = useState<Date | undefined>(undefined)
    const [userAutoComplete, setUserAutoComplete] = useState<AutoCompleteResponse | undefined>()
    const [userAutoCompleteLoading, setUserAutoCompleteLoading] = useState<boolean>(false)

    const {getClassReport, getStudentReport} = props

    async function getUserAutoComplete(id: number){
        setUserAutoCompleteLoading(true)
        let response = await search(id.toString(), "user", 5)
        setUserAutoComplete(response)
        setUserAutoCompleteLoading(false)
    }

    useEffect(() => {
        if(userId && userId > 0)
            getUserAutoComplete(userId)
    }, [userId])

    function handleDateChange(newDate: string){
        let result = Date.parse(newDate) 
        if(result)
            setDate(new Date(result))
    }

    function handleGetClassReport(){
        getClassReport(date);
    }

    function handleGetStudentReport(){
        getStudentReport(userId, date);
    }

    function handleClearDate(){
        setDate(undefined)
    }

    return (
        <div className={"search-container"}>
            <label>Student ID</label>
            <input
                type="number"
                value={userId}
                onChange={e => setUserId(parseInt(e.target.value))}
            />
            {userAutoCompleteLoading && <div>loading</div>}
            {!userAutoCompleteLoading && userAutoComplete && userAutoComplete.items &&
                userAutoComplete.items.map(x => 
                    <p>{x.identifier}</p>
                    )
            }
            <br/>
            <label>Date</label>
            <input
                type="date"
                value={date?.toISOString().substring(0, 10) ?? undefined}
                onChange={e => handleDateChange(e.target.value)}/>

            <button onClick={handleClearDate}>Clear Date</button>
            <br/>
            <button onClick={handleGetStudentReport}>Get Student Report</button>
            <button onClick={handleGetClassReport}>Get Class Report</button>
        </div>
    )
}

export default Search;