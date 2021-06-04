import React, { Component } from 'react';
import Loader from "react-loader-spinner";

export class FetchData extends Component {
  static displayName = FetchData.name;
  constructor(props) {
    super(props);
    this.state = { travels: [], loading: true, resLoading: false };

  }

  componentDidMount() {
    const { match: { params } } = this.props;
    this.populateTravelsData(params);
  }
  formatDate(date)
  {
    const datetime = new Date(date);
    return datetime.getFullYear() + "-" + datetime.getMonth() + "-" + datetime.getDay() + " " + datetime.getHours() + ":" + datetime.getMinutes();
  }

  renderTravelsTable(travels) {
    let contents = this.state.resLoading
      ? <div className="col-12 text-center">
        <Loader
          type="Rings"
          color="#00BFFF"
          height={100}
          width={100}
          timeout={5000}
        />
      </div>
      : travels.map(travel =>
        <tr key={travel.id}>
          <td>{travel.id}</td>
          <td>{travel.title}</td>
          <td>{travel.fromCity.name}</td>
          <td>{travel.toCity.name}</td>
          <td>{travel.availableSeats}</td>
          <td>{this.formatDate(travel.startAt)}</td>
          <td><div className="btn btn-danger" onClick={() => this.makeReservation(travel.id)}>Make a reservation</div></td>
        </tr>
      )
    return (
      <table className='table table-striped' aria-labelledby="tabelLabel">
        <thead>
          <tr>
            <th>#</th>
            <th>Title</th>
            <th>From</th>
            <th>To</th>
            <th>Seats Available</th>
            <th>Starts At</th>
            <th>Action</th>
          </tr>
        </thead>
        <tbody>
              { contents }
        </tbody>
      </table>
    );
  }

  render() {
    let contents = this.state.loading
      ? <div className="col-12 text-center">
        <Loader
          type="Rings"
          color="#00BFFF"
          height={100}
          width={100}
          timeout={5000}
        />
      </div>
      : this.renderTravelsTable(this.state.travels);

    return (
      <div>
        <h1 id="tabelLabel" >Travels</h1>
        {contents}
      </div>
    );
  }

  async populateTravelsData(params) {
    const from = params.travelFrom;
    const to = params.travelTo;
    const response = await fetch(`api/travels/${from}/${to}`);
    const data = await response.json();
    this.setState({ travels: data, loading: false });
  }
  async makeReservation(id)
  {
    this.setState({resLoading: true})
    const response = await fetch(`api/travels/${id}`, { method: 'POST' });
    if (response.status !== 204)
    {
      console.log("error in the reservation :(");
    }
    const travels = [...this.state.travels];
    let travel = travels.find(t => t.id === id);
    if (travel.availableSeats > 0)
    {
      travel.availableSeats = travel.availableSeats - 1;
      this.setState({ travels: travels, resLoading: false });
    }
  }
}
