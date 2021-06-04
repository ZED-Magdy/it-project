import React, { Component } from 'react';
import { Link } from 'react-router-dom';
import Loader from "react-loader-spinner";
export class Home extends Component {
  static displayName = Home.name;
  constructor(props) {
    super(props);
    this.state = { cities: [], loading: true, from: 0, to: 0 };
    this.changeFrom = this.changeFrom.bind(this);
    this.changeTo = this.changeTo.bind(this);
  }
  componentDidMount() {
    this.populateCitiesData();
  }
  changeFrom(event) {
    this.setState({ from: event.target.value });
  }
  changeTo(event) {
    this.setState({ to: event.target.value });
  }
  render() {
    let contents = this.state.loading
      ? <div className="col-12 text-center">
        <Loader
          type="Rings"
          color="#00BFFF"
          height={100}
          width={100}
          timeout={3000} //3 secs
        />
      </div>
      : this.renderCities(this.state.cities);
    return (
      <div className="row">
        <div className="col-12 text-center mt-5 p-5">
          <h1>Where do you want to go?</h1>
        </div>
        { contents }
        </div>
    );
  }
  renderCities(cities) {
    return (
      <div className="col-10 offset-2">
        <div className="row mt-5">
          <div className="col-md-4 col-sm-12">
            <div className="row">
              <label htmlFor="from" className="col-sm-2 col-form-label">From</label>
              <select className="col-10 form-control" value={ this.state.from } onChange={ this.changeFrom } id="from">
                {cities.map(city => (
                  <option key={city.id} value={city.id}>{city.name}</option>
                ))}
              </select>
            </div>
          </div>
          <div className="col-md-4 col-sm-12">
            <div className="row mb-3">
              <label htmlFor="to" className="col-sm-2 col-form-label">To</label>
              <select className="col-10 form-control d-inline-block" id="to" value={ this.state.to } onChange={ this.changeTo }>
                {cities.slice().reverse().map(city => (
                  <option key={city.id} value={city.id}>{city.name}</option>
                ))}
              </select>
            </div>
          </div>
          <div className="col-md-4 col-sm-12">
            <Link className="btn btn-danger search-btn" to={{ pathname: `/travels/${this.state.from}/${this.state.to}` }}>Search</Link>
          </div>
        </div>
      </div>
    );
  }
  async populateCitiesData() {
    const response = await fetch(`api/travels/cities`);
    const data = await response.json();
    const from = data[0].id;
    const to = data[data.length - 1].id;
    this.setState({ cities: data, from: from, to: to, loading: false });
  }
}
