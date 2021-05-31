import { NamedBinaryReport } from "../types/Report";

interface IProps{
    data: NamedBinaryReport
}

const ListReport = (props : IProps) => {
    const {name, trueCount, falseCount} = props.data

    return (
        <div className={"report-container"}>
            <b>{name}</b>
            <table>
                <thead>
                    <tr>
                        <td>true</td>
                        <td>false</td>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td>{trueCount}</td>
                        <td>{falseCount}</td>
                    </tr>
                </tbody>
            </table>
        </div>
    )
}

export default ListReport;