import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, Observable, of } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Member } from '../_models/member';

// const httpOptions = {
//   headers: new HttpHeaders({
//     Authorization: 'Bearer ' + JSON.parse(localStorage.getItem('user'))?.token
//   })
// }

@Injectable({
  providedIn: 'root'
})
export class MembersService {
  baseUrl = environment.apiUrl;
  members: Member[] = [];

  constructor(private http: HttpClient) { }


// getMembers(): Observable<Member[]> {                              // NOK
    // return this.http.get(this.baseUrl + 'users', httpOptions);    // NOK
// }

  // getMembers() {
  //   // return this.http.get<Member[]>(this.baseUrl + 'users', httpOptions);
  //   return this.http.get<Member[]>(this.baseUrl + 'users');
  // }

  getMembers() {
    if (this.members.length > 0) return of(this.members);
    return this.http.get<Member[]>(this.baseUrl + 'users').pipe(
      map(members => {
        this.members = members;
        return members;
      })
    )
  }

  // getMember(username: string) {
  //   // return this.http.get<Member[]>(this.baseUrl + 'users/' + username, httpOptions);
  //   // return this.http.get<Member[]>(this.baseUrl + 'users/' + username);
  //   return this.http.get<Member>(this.baseUrl + 'users/' + username);
  // }

  getMember(username: string) {
    const member = this.members.find(x => x.username === username);
    if (member !== undefined) return of(member);
    return this.http.get<Member>(this.baseUrl + 'users/' + username);
  }

  // updateMember(member: Member) {
  //   return this.http.put(this.baseUrl + 'users', member);
  // }

  updateMember(member: Member) {
    return this.http.put(this.baseUrl + 'users', member).pipe(
      map(() => {
        const index = this.members.indexOf(member);
        this.members[index] = member;
      })
    )
  }
}
